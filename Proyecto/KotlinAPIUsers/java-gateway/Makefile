#makefile for purplelab-api-admincenter
compile:
	@gradle build -x test

clean:
	@gradle clean

execute:
	@java -jar -Dspring.profiles.active=dev build/libs/gs-gateway-0.1.0.jar
