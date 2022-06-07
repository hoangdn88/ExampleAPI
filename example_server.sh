#!/bin/bash

#remove docker container
docker rm -f exampleapi_container || true

#pull docker image
docker pull hoangdntb88/ampleapi:latest

#build docker image
docker build -t hoangdntb88/ampleapi .

#run docker container
docker run -it -p 8888:8888 hoangdntb88/ampleapi:latest --name exampleapi_container