# kotlin-users-service-api
API Service to admin users

## Prerequirements
1. Gradle 4.10
2. Java, Kotlin

## Prerequisites
- Docker


## Building
```
gradle build

or 

gradle build -x test

or

make compile
```

## Running
```
java -jar -Dspring.profiles.active=dev build/libs/purplelab-api-admincenter-1.1-local-SNAPSHOT.war

or

or make execute ENV=[local|dev|stage|prod]
```


https://dzone.com/articles/jwts-with-spring-boot-and-java-9


## Install JDK 8
https://www3.ntu.edu.sg/home/ehchua/programming/howto/JDK_Howto.html

https://docs.datastax.com/en/jdk-install/doc/jdk-install/installOpenJdkDeb.html

https://www.shaileshjha.com/step-by-step-how-to-download-and-install-java-se-jdk-8-on-windows-10/

https://www.cs.dartmouth.edu/~scot/cs10/mac_install/mac_install.html

JDK 8
Debian, Ubuntu, etc.

On the command line, type:

    $ sudo apt-get install openjdk-8-jre

The openjdk-8-jre package contains just the Java Runtime Environment. If you want to develop Java programs then please install the openjdk-8-jdk package.
Fedora, Oracle Linux, Red Hat Enterprise Linux, etc.

On the command line, type:

    $ su -c "yum install java-1.8.0-openjdk"

The java-1.8.0-openjdk package contains just the Java Runtime Environment. If you want to develop Java programs then install the java-1.8.0-openjdk-devel package.


## Install Gradle
https://gradle.org/install/
https://linuxize.com/post/how-to-install-gradle-on-ubuntu-18-04/
https://stackoverflow.com/questions/34856932/how-do-i-install-gradle-on-windows-10
https://stackoverflow.com/questions/34856932/how-do-i-install-gradle-on-windows-10/37774085#37774085


http://localhost:8080/v2/api-docs