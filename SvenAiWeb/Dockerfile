FROM node:14-alpine
RUN mkdir -p /usr/src/nuxt-app
WORKDIR /usr/src/nuxt-app

RUN apk update && apk upgrade
RUN apk add git python2 make g++

COPY .  /usr/src/nuxt-app
RUN npm install

RUN npm run build

EXPOSE 80

ENV NUXT_HOST=0.0.0.0
ENV NUXT_PORT=80

CMD ["npm", "start"]