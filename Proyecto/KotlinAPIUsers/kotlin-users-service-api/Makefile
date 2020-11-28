#makefile for purplelab-api-admincenter
compile:
	@gradle build -x test

clean:
	@gradle clean

execute:
	@java -jar -Dspring.profiles.active=dev build/libs/puj-api-admincenter-2.0.0-SNAPSHOT.jar
