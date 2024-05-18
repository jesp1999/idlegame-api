const express = require('express');
const cors = require('cors');
const { json } = require('body-parser');
const fs = require('fs');

const { createHandler } = require("graphql-http/lib/use/express")
const { buildSchema } = require('graphql');
const { parse } = require('csv-parse/sync');
const path = require('path');

const {ruruHTML} = require("ruru/server");

const app = express()
    .use(cors())
    .use(json());

const schema = buildSchema(fs.readFileSync(path.resolve(__dirname, 'schema.graphql'), 'utf8'));
const characters = parse(fs.readFileSync(path.resolve(__dirname, '../data/characters.csv'), 'utf8'), { columns: true });
const species = parse(fs.readFileSync(path.resolve(__dirname, '../data/species.csv'), 'utf8'), { columns: true });

const root = {
    characters: (args) => {
        return {
            count: characters.length,
            characters: characters.slice(args.offset, args.offset + args.limit)
        };
    },
    character: (args) => {
        return characters.find((ch) => ch.name === args.name);
    },
    species: (args) => {
        return species.find((ch) => ch.name === args.name);
    },
};

app.use('/graphql', createHandler({
    schema,
    rootValue: root,
    graphiql: true,
}));

// Serve the GraphiQL IDE.
app.get("/", (_req, res) => {
    res.type("html")
    res.end(ruruHTML({ endpoint: "/graphql" }))
})

app.listen(4201, (err) => {
    if (err) {
        return console.log(err);
    }
    return console.log('Server listening on port 4201');
});
