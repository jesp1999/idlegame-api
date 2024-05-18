FROM node:latest AS build
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN ["npm", "install"]
COPY . .
CMD ["npm", "run", "build", "--configuration=production", "--output-path=dist"]
EXPOSE 4201
ENTRYPOINT ["node"]
CMD ["api/app.ts"]
