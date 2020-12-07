package com.puj.admincenter.service

import com.puj.admincenter.domain.users.User
import com.puj.admincenter.dto.users.UserDto
import com.puj.admincenter.dto.users.CreateUserDto
import com.puj.admincenter.dto.users.UpdateUserDto
import com.puj.admincenter.dto.IdResponseDto
import com.puj.admincenter.repository.users.UserRepository

import org.springframework.data.domain.Pageable
import org.springframework.data.domain.Page
import org.springframework.security.crypto.bcrypt.BCrypt
import org.springframework.stereotype.Service
import org.springframework.http.ResponseEntity
import org.springframework.http.HttpStatus
import org.springframework.web.bind.annotation.*
import org.slf4j.LoggerFactory
import java.io.Serializable
import java.util.*

@Service
class UserService(private val userRepository: UserRepository) {
    companion object {
        val LOG = LoggerFactory.getLogger(UserService::class.java)!!
    }

    fun count(): Long {
        return userRepository.count()
    }

    fun getAllUsers(authorization: String): ResponseEntity<*> {
        return ResponseEntity.ok(userRepository.findAll())
    }

    fun getById(userId: Int,
                authorization: String): ResponseEntity<*> {

        val user = userRepository.findById(userId)  // Hace solo el query
        return if (user.isPresent()) {
            ResponseEntity.ok(UserDto.convert(user.get()))
        } else {
            ResponseEntity<Any>(HttpStatus.NOT_FOUND)
        }
    }

    fun create(createUserDto: CreateUserDto): ResponseEntity<*> {
        if (userRepository.existsByEmail(createUserDto.email)) {
            val messageError = "User with email: ${createUserDto.email} already exists."
            LOG.error(messageError)
            return ResponseEntity<Any>(messageError,
                                       HttpStatus.CONFLICT)
        }

        val user = User(email = createUserDto.email,
                        name = createUserDto.name,
                        password = createUserDto.password,
                        username = createUserDto.username)
        val userSaved = userRepository.save(user)
        LOG.info("User ${createUserDto.email} created with id ${userSaved.id}")

        val responseDto = IdResponseDto(userSaved.id.toLong())
        return ResponseEntity<IdResponseDto>(responseDto,
                                             HttpStatus.CREATED)
    }

    fun edit(userId: Int,
             updateUserDto: UpdateUserDto): ResponseEntity<*> {
        val currentUser = userRepository.findById(userId);
        return if(currentUser.isPresent()) {
            val updateUser:User = currentUser.get().copy(
				email = updateUserDto.email,
                name = updateUserDto.name,
                username = updateUserDto.username,
				password = updateUserDto.password
            )
            val userSaved = userRepository.save(updateUser)
            LOG.info("User ${userSaved.email} was updated successfully")
    
            ResponseEntity<Any>(HttpStatus.OK)
        } else {
            LOG.error("User not found")
            ResponseEntity<Any>(HttpStatus.NOT_FOUND)
        }
    }

    fun delete(userId: Int): ResponseEntity<*> {
        val currentUser = userRepository.findById(userId);
        return if(currentUser.isPresent()) {
            userRepository.deleteByUserId(userId)
            LOG.info("User with id $userId was deleted successfully")

            ResponseEntity<Any>(HttpStatus.OK)
        } else {
            LOG.error("User not found")
            ResponseEntity<Any>(HttpStatus.NOT_FOUND)
        }
    }
}
