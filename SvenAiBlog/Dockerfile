FROM node:14-slim

VOLUME /blog

RUN \
 apt-get update && \
 apt-get install git -y && \
 npm install -g hexo-cli

WORKDIR /blog

ENTRYPOINT [ "hexo" ]