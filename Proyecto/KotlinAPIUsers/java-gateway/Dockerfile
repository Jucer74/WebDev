FROM openjdk:8-jre-alpine
VOLUME /tmp
COPY ./build/libs/gs-gateway-0.1.0.jar app.jar
RUN mv /usr/lib/jvm/java-1.8-openjdk/jre/lib/amd64/jli/libjli.so /lib
RUN apk update && apk add netcat-openbsd busybox-extras

ENTRYPOINT ["java", "-Djava.security.egd=file:/dev/./urandom", "-jar", "/app.jar"]

