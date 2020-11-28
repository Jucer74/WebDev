package com.purplelab.admincenter.authorization.jwt

import com.auth0.jwt.JWT
import com.auth0.jwt.exceptions.JWTDecodeException
import com.auth0.jwt.interfaces.DecodedJWT
import org.slf4j.LoggerFactory
import org.springframework.stereotype.Component

@Component
public class JWTDecoder() {

    companion object {
        private val LOG = LoggerFactory.getLogger(JWTDecoder::class.java)
    }   

    @Throws(JWTDecodeException::class)
    fun getClientID(authorizationHeader: String): String? {
        try {
            val token = authorizationHeader.replace("Bearer ", "")
            val jwt = JWT.decode(token)
            val subject = jwt.getSubject()
            val clientID = subject.replace("@clients", "")
            LOG.info("ClientID: $clientID")
            return clientID
        } catch (e: JWTDecodeException) {
            LOG.info("Failed to decode token as jwt", e)
            throw JWTDecodeException("Failed to decode token as jwt", e)
        }
    }
}