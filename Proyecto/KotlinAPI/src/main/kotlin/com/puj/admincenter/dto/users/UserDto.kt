package com.puj.admincenter.dto.users

import com.puj.admincenter.domain.users.User

data class UserDto(
    val id: Int,
    val email: String,
    var username: String
) {
    companion object {
        fun convert(user: User): UserDto {
            val dto = UserDto(
                id = user.id,
                email = user.email,
                username = user.username
            )
            return dto
        }
    }
}