package com.puj.admincenter

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

import com.puj.admincenter.security.JWTAuthorizationFilter;

import org.springframework.context.annotation.Bean
import springfox.documentation.spring.web.plugins.Docket
import springfox.documentation.spring.web.paths.RelativePathProvider
import springfox.documentation.service.ApiInfo
import springfox.documentation.service.Contact
import springfox.documentation.spi.DocumentationType
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry
import springfox.documentation.builders.RequestHandlerSelectors
import springfox.documentation.builders.PathSelectors.regex
import springfox.documentation.builders.ApiInfoBuilder

import org.springframework.context.annotation.Configuration
import org.springframework.security.config.annotation.web.builders.HttpSecurity
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter

import springfox.documentation.swagger2.annotations.EnableSwagger2

@SpringBootApplication
@EnableSwagger2
class PujApiAdminCenterApplication {
    companion object {
        @JvmStatic
        fun main(args: Array<String>) {
            runApplication<PujApiAdminCenterApplication>(*args)
        }
    }

    @EnableWebSecurity
    @Configuration
    class WebSecurityConfig : WebSecurityConfigurerAdapter() {
        override fun configure(httpSecurity: HttpSecurity) {
            httpSecurity
                    .cors()
                    .and()
                    .csrf().disable()
                    .antMatcher("login/**")
                    .authorizeRequests() //a partir de aqui te pide el token
                    .anyRequest()
                    .authenticated()
                    .and()
                    .addFilterAfter(JWTAuthorizationFilter(), UsernamePasswordAuthenticationFilter::class.java)
                    .authorizeRequests()
        }
    }

    /*
     This defines the Swagger2 configuration to Springfox
     if the package the controllers live in changes or one is added,
     the package named here needs to change.
     You can also keep springfox from documenting parts of your API
     you don't want to by manipulating the .paths() directive.
    */
    @Bean
    fun amtApiDocket(): Docket {
        return Docket (DocumentationType.SWAGGER_2)
            .host("localhost")
            .select().apis(RequestHandlerSelectors.basePackage("com.puj.admincenter.controller"))
            .paths(regex("/.*"))
            .build().pathProvider(object : RelativePathProvider(null) {
                override fun getApplicationBasePath(): String {
                    return "/api"
                }
            })
            .apiInfo(defineApiMetaData())
    }

    fun defineApiMetaData(): ApiInfo {
        return ApiInfoBuilder()
                .title("AdminCenter PUJ API")
                .description("\"AdminCenter PUJ RESTful API\"")
                .version("1.1.0") // TODO: pull this from the application config
                // .license("Apache License Version 2.0")
                // .licenseUrl("https://www.apache.org/licenses/LICENSE-2.0\"")
                // just guessing here...
                //.contact(Contact("Mark Brosso", "https://purplelab.com", "markbrosso@gmail.com"))
                .build();
    }

    @Override
    fun addResourceHandlers(registry: ResourceHandlerRegistry) {
        registry.addResourceHandler("swagger-ui.html")
        .addResourceLocations("classpath:/META-INF/resources/")
    
        registry.addResourceHandler("/webjars/**")
        .addResourceLocations("classpath:/META-INF/resources/webjars/")
    }
}
