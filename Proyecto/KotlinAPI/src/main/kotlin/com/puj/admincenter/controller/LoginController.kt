package com.puj.admincenter.controller

import com.puj.admincenter.dto.login.LoginDto
import com.puj.admincenter.dto.login.TokenDto
import com.puj.admincenter.service.LoginService

import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.RestController
import org.springframework.web.bind.annotation.CrossOrigin
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.http.ResponseEntity
import javax.validation.constraints.NotNull
import javax.validation.Valid

@CrossOrigin
@RequestMapping("/login")
@RestController
class LoginController(val loginService: LoginService) {
    @PostMapping(
        consumes = ["application/json"],
        produces = ["application/json"]
    )
    fun login(@RequestBody(required = true) @Valid loginDto: LoginDto): ResponseEntity<*>
        = loginService.login(loginDto)
}