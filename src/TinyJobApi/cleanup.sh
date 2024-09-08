#!/bin/zsh
# check if docker has been installed
if ! [ -x "$(command -v docker)" ]; then
  echo 'Error: docker is not installed.' >&2
  exit 1
fi

# stop and rm postgres container
docker stop postgres-container
docker rm postgres-container