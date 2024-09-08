#!/bin/zsh
# check if docker has been installed
if ! [ -x "$(command -v docker)" ]; then
  echo 'Error: docker is not installed.' >&2
  exit 1
fi

# setup postgres
# if can't find the postgres container, pull the image and create a volume
if ! docker image inspect postgres > /dev/null 2>&1; then
  docker pull postgres
fi

if ! docker volume inspect postgres-data > /dev/null 2>&1; then
  docker volume create postgres-data
fi

# run the postgres container
if docker ps -a --format '{{.Names}}' | grep -Eq "^postgres-container$"; then
  docker start postgres-container
else
echo "Enter the password for the postgres user postgres: "
read password
docker run --name postgres-container -e POSTGRES_PASSWORD="$password" -p 5432:5432 -v postgres-data:/var/lib/postgresql/data -d postgres
dotnet user-secrets set "ConnectionStrings:PostgreSQL" "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=$password"
fi