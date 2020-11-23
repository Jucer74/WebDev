package com.puj.admincenter.service

import com.puj.admincenter.domain.users.User
import com.puj.admincenter.dto.login.LoginDto
import com.puj.admincenter.dto.login.TokenDto
import com.puj.admincenter.repository.users.UserRepository

import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;

import org.springframework.beans.factory.annotation.Value
import org.springframework.http.ResponseEntity
import org.springframework.http.HttpStatus
import org.springframework.security.crypto.bcrypt.BCrypt
import org.springframework.stereotype.Service
import java.util.stream.Collectors
import org.slf4j.LoggerFactory
import java.util.Calendar
import java.util.*

@Service
class LoginService(val userRepository: UserRepository) {
    companion object {
        val logger = LoggerFactory.getLogger(LoginService::class.java)!!
    }

    @Value(value = "\${jwt.secret}")
    private val jwtSecret: String? = null

    @Value(value = "\${jwt.expiration:5}")
    private val jwtExpiration: Long = 5

    fun login(loginDto: LoginDto): ResponseEntity<*> {
        val user = userRepository.findUserByUserAndPassword(loginDto.username,
                                                            loginDto.password)
        return if (user != null) {
            logger.info("found user $user")
            val jwtToken = getJWTToken(loginDto.username)
    
            println("tokenJwt: $jwtToken")

            val token =  TokenDto(jwtToken,
                                  user.id)
            logger.info("Token $token for user $user generated")
            ResponseEntity<TokenDto>(token,
                                     HttpStatus.OK)
        } else {
            val message = "the user does not exist or is not enabled" 
            logger.error(message)
            ResponseEntity<String>(message,
                                   HttpStatus.NOT_FOUND)
        }
    }

    fun getJWTToken(username:String): String {
        val secretKey = "mySecretKey"
        val grantedAuthorities = AuthorityUtils.commaSeparatedStringToAuthorityList("ROLE_USER")
        val claims = Jwts.claims()
                         .setSubject(username)
        claims.put("identity", username)
        val token = Jwts.builder()
                        .setId("softtekJWT")
                        .setClaims(claims)
                        .claim("authorities", 
                               grantedAuthorities.stream()
                                                 .map(GrantedAuthority::getAuthority)
                                                 .collect(Collectors.toList()))
                        .setIssuedAt(Date(System.currentTimeMillis()))
                        .setExpiration(Date(System.currentTimeMillis() + 600000))
                        .signWith(SignatureAlgorithm.HS512,
                                  secretKey.toByteArray()).compact()
        return "Bearer " + token
    }
}

// Note:
// RS256 vs HS256

// When creating clients and resources servers (APIs) in Auth0, two algorithms are supported for signing 
// JSON Web Tokens (JWTs): RS256 and HS256. HS256 is the default for clients and RS256 is the default for APIs. 
// When building applications, it is important to understand the differences between these two algorithms.
//  To begin, HS256 generates a symmetric MAC and RS256 generates an asymmetric signature. Simply put HS256 
//  must share a secret with any client or API that wants to verify the JWT. Like any other symmetric algorithm, 
//  the same secret is used for both signing and verifying the JWT. This means there is no way to fully 
//  guarantee Auth0 generated the JWT as any client or API with the secret could generate a validly signed JWT. 
//  On the other hand, RS256 generates an asymmetric signature, which means a private key must be used to sign 
//  the JWT and a different public key must be used to verify the signature. Unlike symmetric algorithms, 
//  using RS256 offers assurances that Auth0 is the signer of a JWT since Auth0 is the only party with the 
//  private key.

// https://auth0.com/blog/navigating-rs256-and-jwks/