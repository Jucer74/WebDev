import org.jetbrains.kotlin.gradle.tasks.KotlinCompile

plugins {
	id("org.springframework.boot") version "2.2.4.RELEASE"
	id("io.spring.dependency-management") version "1.0.9.RELEASE"
	kotlin("jvm") version "1.3.61"
	kotlin("plugin.spring") version "1.3.61"
	kotlin("plugin.jpa") version "1.3.61"

}
group = "kotlin-users-service-api"
version = "2.0.0-SNAPSHOT"
java.sourceCompatibility = JavaVersion.VERSION_1_8
repositories {
	mavenCentral()
}


dependencies {
	implementation("org.springframework.boot:spring-boot-starter-data-jpa")
	implementation("org.springframework.boot:spring-boot-starter-web")
	implementation("com.fasterxml.jackson.module:jackson-module-kotlin")
	implementation("org.jetbrains.kotlin:kotlin-reflect")
	implementation("org.jetbrains.kotlin:kotlin-stdlib-jdk8")
	implementation("org.springframework.boot:spring-boot-starter-web")
    compile("io.springfox:springfox-swagger2:2.9.2")
    compile("io.springfox:springfox-swagger-ui:2.9.2")
    compile("org.springframework.boot:spring-boot-starter-security")
    runtimeOnly("mysql:mysql-connector-java")
	testImplementation("org.springframework.boot:spring-boot-starter-test") {
		exclude(group = "org.junit.vintage", module = "junit-vintage-engine")
    }
    compile(group="com.amazonaws", name="aws-java-sdk-cognitoidp", version="1.11.731")
    compile(group="com.amazonaws", name="aws-java-sdk-api-gateway", version="1.11.754")
    compile(group="com.amazonaws", name="aws-java-sdk-ssm", version="1.11.858")
    compile("io.fusionauth:fusionauth-jwt:3.5.3")
    implementation( "com.auth0:java-jwt:3.9.0")
    compile(group="com.auth0", name="auth0-spring-security-api", version="1.4.0")
    	// The JWT library 
	compile(group="io.jsonwebtoken", name="jjwt", version="0.9.1")
}

tasks.withType<Test> {
	useJUnitPlatform()
}
tasks.withType<KotlinCompile> {
	kotlinOptions {
		freeCompilerArgs = listOf("-Xjsr305=strict")
		jvmTarget = "1.8"
	}
}

