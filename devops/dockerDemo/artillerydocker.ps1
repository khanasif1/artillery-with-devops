#***********************
#****Check Images*******
#***********************
docker images -a 
docker ps -a


#***********************
#****Check Images*******
#***********************
cd ./dockerDemo
docker run --name artilleryloadtest --rm -it -v ${PWD}:/scripts  artilleryio/artillery:latest run /scripts/load.yml --output /scripts/load-run.json



#***********************
#****Cleanup container**
#***********************

docker rm artilleryloadtest -f
docker rmi artillery-aci:latest -f


