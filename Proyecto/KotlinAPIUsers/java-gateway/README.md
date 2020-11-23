## API Gateway pattern description
https://microservices.io/patterns/apigateway.html

## Prerequisites 

For the gateway to work, user services (java) and movie services (python) must be running on different ports.

## Steps to create the api gateway

========================================================================================================================
======================================= To create structure of the project =============================================
======================================================================================================================== 

1. in the current folder (java-gateway), to create the structure of the java code:

mkdir -p src/main/java/com/puj/gateway

2. in the current folder (java-gateway), to create the structure of the configuration file of the gateway

mkdir -p src/main/resources

========================================================================================================================
================================== To create gradle file to handle dependencies ========================================
======================================================================================================================== 

3. in the current folder (java-gateway), to create the file build.gradle in the root of the project (at the same level of src folder) with this content:

buildscript {
    repositories {
        mavenCentral()
    }
    dependencies {
        classpath("org.springframework.boot:spring-boot-gradle-plugin:2.1.7.RELEASE")
    }
}

apply plugin: 'java'
apply plugin: 'eclipse'
apply plugin: 'idea'
apply plugin: 'org.springframework.boot'
apply plugin: 'io.spring.dependency-management'

bootJar {
    baseName = 'gs-gateway'
    version =  '0.1.0'
}

repositories {
    mavenCentral()
}

sourceCompatibility = 1.8
targetCompatibility = 1.8

dependencyManagement {
    imports {
        mavenBom "org.springframework.cloud:spring-cloud-dependencies:Greenwich.SR2"
    }
}

dependencies {
    compile group: 'commons-io', name: 'commons-io', version: '2.6'
    compile group: 'org.springframework.security', name: 'spring-security-core', version: '3.0.3.RELEASE'
    compile("org.springframework.cloud:spring-cloud-starter-gateway")
    compile("org.springframework.cloud:spring-cloud-starter-netflix-hystrix")
    compile("org.springframework.cloud:spring-cloud-starter-contract-stub-runner"){
        exclude group: "org.springframework.boot", module: "spring-boot-starter-web"
    }
    testCompile("org.springframework.boot:spring-boot-starter-test")
}

========================================================================================================================
================================ To create configuration file to set the services ======================================
======================================================================================================================== 

4. in the folder (java-gateway/src/main/resources), to create the application.yml file in the same place of the build.gradle

server:
  port: 9999

logging:
  level:
    org.springframework.cloud.gateway: ERROR
    org.springframework.http.server.reactive: ERROR
    org.springframework.web.reactive: ERROR
    reactor.ipc.netty: ERROR
    reactor.netty: ERROR

services:
  userservice: http://localhost:8080
  movieservice: http://localhost:5000

5. As you can see the file application.yml has the url of each service (users and movies), verify that the services
have the right urls. Remember the services must be running.

=====================================================================================
===================== Now, let's create the code for the gateway ====================
=====================================================================================

6. first, let's to create a file to logging all the request that receives the gateway, so, the idea is to create file 
to allow print the request information in our logs, for that in src/main/java/com/puj/gateway, to create the file SimpleLoggingFilter.java with this content:

package com.puj.gateway;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.cloud.gateway.filter.GatewayFilter;
import org.springframework.cloud.gateway.filter.GatewayFilterChain;
import org.springframework.stereotype.Component;
import org.springframework.web.server.ServerWebExchange;
import reactor.core.publisher.Mono;

@Component
public class SimpleLoggingFilter implements GatewayFilter {

    private static final Logger log = LoggerFactory.getLogger(SimpleLoggingFilter.class);

    @Override
    public Mono<Void> filter(ServerWebExchange exchange, GatewayFilterChain chain) {
        log.info("***************************************************");
        log.info("Method:{} Host:{} Path:{} QueryParams:{} Headers:{}",
                exchange.getRequest().getMethod(),
                exchange.getRequest().getURI().getHost(),
                exchange.getRequest().getURI().getPath(),
                exchange.getRequest().getQueryParams(),
                exchange.getRequest().getHeaders());
        log.info("***************************************************");
        return chain.filter(exchange);
    }
}

7. Now, the code of the gateway, in src/main/java/com/puj/gateway, to create the file Application.java with this content:

package com.puj.gateway;

import reactor.core.publisher.Mono;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.cloud.gateway.route.RouteLocator;
import org.springframework.cloud.gateway.route.builder.RouteLocatorBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.server.ServerWebExchange;
import org.springframework.core.env.Environment;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import java.net.UnknownHostException;
import org.apache.commons.lang.StringUtils;
import java.text.MessageFormat;
import org.apache.commons.io.IOUtils;

@SpringBootApplication
@RestController
public class Application {

    @Value("${services.users}")
    private String usersService;

    @Value("${services.movies}")
    private String moviesService;

    private static final Logger logger = LoggerFactory.getLogger(Application.class);

    public static void main(String[] args) {
        Environment env = SpringApplication.run(Application.class, args).getEnvironment();
        try {
            printServerInfo(env);
        }
        catch(UnknownHostException e) {
            logger.error("Error: ", e);
        }
    }    

    @Bean
    public RouteLocator myRoutes(RouteLocatorBuilder routeBuilder,
                                 SimpleLoggingFilter loggingFilter) {
        String httpUriUsers = usersService;
        String httpUirMovies = moviesService;

        return routeBuilder.routes()
            .route("users",
                route -> route
                    .path("/api/gateway/usersservice/**")
                    .filters(
                        f -> {
                            f.stripPrefix(3);
                            f.filter(loggingFilter);
                            return f;
                        }
                    )
                    .uri(httpUriUsers)
            )
            .route("movies",
                route -> route
                    .path("/api/gateway/moviesservice/**")
                    .filters(
                        f -> {
                          f.stripPrefix(3);
                          f.filter(loggingFilter);
                          return f;
                        }
                    )
                    .uri(httpUirMovies)
            )
            .build();   
    }

    @RequestMapping("/ping")
    public Mono<String> ping() {
        return Mono.just("pong");
    }

    public static void printServerInfo(Environment env) throws UnknownHostException {
        String serverInfo = MessageFormat.format(
                "Application is running:\n"
                        + "------------------------------------------------------------------------\n\t"
                        + "Application:     {0}\n\t"
                        + "Local IP:        {1}://127.0.0.1:{2}{3}\n\t"
                        + "Public IP:       {4}://{5}:{6}{7}\n\t"
                        + "Profiles:        {8}\n\t"
                        + "PID:             {9}\n\t"
                        + "usersService:    {10}\n\t"
                        + "moviesService:   {11}\n"
                        + "------------------------------------------------------------------------",
                env.getProperty("spring.application.name"),
                StringUtils.isEmpty(env.getProperty("server.ssl.key-store")) ? "http" : "https",
                env.getProperty("server.port"),
                StringUtils.isEmpty(env.getProperty("server.context-path")) ? "" : env.getProperty("server.context-path"),
                StringUtils.isEmpty(env.getProperty("server.ssl.key-store")) ? "http" : "https",
                BaseUtils.getLocalIpv4(),
                env.getProperty("server.port"),
                StringUtils.isEmpty(env.getProperty("server.context-path")) ? "" : env.getProperty("server.context-path"),
                org.springframework.util.StringUtils.arrayToCommaDelimitedString(env.getActiveProfiles()),
                System.getProperty("PID"),
                env.getProperty("services.users"),
                env.getProperty("services.movies"));
        logger.info(serverInfo);
    }    
}


8. Let's to create a file to allow get the local ipv4, in in src/main/java/com/puj/gateway, to create the file BaseUtils.java  with this content:

package com.puj.gateway;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;

import java.net.Inet6Address;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.UnknownHostException;
import java.util.Enumeration;


public class BaseUtils {
    private static final Logger logger = LoggerFactory.getLogger(BaseUtils.class);

    public static String getCurrentUser() {
        String username = null;
        Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();

        if (principal instanceof UserDetails) {
            username = ((UserDetails)principal).getUsername();
        } else {
            username = principal.toString();
        }

        return username;
    }

    public static String getLocalIpv4() {
        InetAddress ip;
        try {
            ip = Inet6Address.getLocalHost();
            String localname = ip.getHostName();
            String localip = ip.getHostAddress();
            logger.debug("run server name" + localname +"server ip:"+ localip);
            return  localip;
        } catch (UnknownHostException e) {
            e.printStackTrace();
            logger.error("----get local ipv4 error------"+ e.getMessage());
        }
        return getLocalIp();
    }

    public static String getLocalIp() {
        StringBuffer sb = new StringBuffer();
        try {
            Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces();
            while (en.hasMoreElements()) {
                NetworkInterface ni = (NetworkInterface) en.nextElement();
                Enumeration<InetAddress> enumInetAddr = ni.getInetAddresses();
                while (enumInetAddr.hasMoreElements()) {
                    InetAddress inetAddress = (InetAddress) enumInetAddr.nextElement();

                    if (!inetAddress.isLoopbackAddress() && !inetAddress.isLinkLocalAddress()
                            && inetAddress.isSiteLocalAddress()) {
                        sb.append(inetAddress.getHostAddress().toString());
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            logger.error("----get local ip error------"+ e.getMessage());
        }
        return sb.toString();
    }
}

9. Compile, gradle build -x test or ./gradlew build -x test

10. Execute with java -jar build/libs/gs-gateway-0.1.0.jar

=====================================================================================
============================ Now, let's tests the gateway ===========================
=====================================================================================

11. Use manual_tests.py file to test the gateway.

python3 manual_tests.py