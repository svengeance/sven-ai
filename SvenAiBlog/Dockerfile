FROM node:14-slim AS build
WORKDIR /blog 
RUN \
 apt-get update && \
 apt-get install git -y && \
 rm -rf node_modules && \
 npm install --force
COPY . .
RUN \
 npm i -g hexo-cli && \
 hexo generate

FROM nginx:alpine
COPY --from=build /blog/public /website/blog
EXPOSE 80 443