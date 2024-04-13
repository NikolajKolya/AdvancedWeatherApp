# Create network (to avoid problems with directory prefixes)
docker network create -d bridge advweatherapp-net

# Infrastructure

## Build custom postgresql image
Build image: $ docker build -f dockerfile-advweatherapp-infrastructure-postgres -t advweatherapp-infrastructure-postgres .

## Run Infrastructure

Run containers (debug): $ docker-compose -f docker-compose-advweatherapp-infrastructure.yml up

Run containers (release): $ docker-compose -f docker-compose-advweatherapp-infrastructure.yml up -d

Stop containers: docker-compose -f docker-compose-advweatherapp-infrastructure.yml down