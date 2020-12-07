package com.puj.admincenter.dto.users

data class UpdateUserDto(
    val email: String,
    var name: String,
    var username: String,
    var password: String    
)