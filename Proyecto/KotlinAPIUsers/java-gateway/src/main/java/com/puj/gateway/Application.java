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
