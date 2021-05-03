FROM node:14-alpine
RUN mkdir -p /usr/src/nuxt-app
WORKDIR /usr/src/nuxt-app

EXPOSE 80
ENV NUXT_HOST=0.0.0.0
ENV NUXT_PORT=80

COPY .  /usr/src/nuxt-app

RUN npm install && npm run build

CMD ["npm", "start"]