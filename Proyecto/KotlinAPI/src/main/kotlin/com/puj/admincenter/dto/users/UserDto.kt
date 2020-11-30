package com.puj.admincenter.dto.users

import com.puj.admincenter.domain.users.User

data class UserDto(
    val id: Int,
    val email: String,
    var name: String,
    var username: String,
    var password: String
) {
    companion object {
        fun convert(user: User): UserDto {
            val dto = UserDto(
                id = user.id,
                email = user.email,
                name = user.name,
                username = user.username,
                password = user.password
            )
            return dto
        }
    }
}