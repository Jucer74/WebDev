package com.puj.admincenter.dto.users

data class CreateUserDto(
    val email: String,
    val name: String,
    val username: String,
    val password: String
)