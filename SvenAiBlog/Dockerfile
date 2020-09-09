FROM node:14-slim AS build
WORKDIR /blog 
RUN \
 apt-get update && \
 apt-get install git -y
COPY . .
RUN \
 npm i -g hexo-cli && \
 npm i --force && \
 hexo generate

FROM nginx:alpine
COPY --from=build /blog/public /website/blog
EXPOSE 80 443