package com.puj.admincenter.domain.users

import org.hibernate.annotations.GenericGenerator
import org.springframework.security.core.GrantedAuthority
import org.springframework.security.core.userdetails.UserDetails
import com.fasterxml.jackson.annotation.JsonIgnore
import java.io.Serializable
import java.util.*
import javax.persistence.*

@Entity
@Table(name = "user")
data class User(
    @Id
    @Column(name = "id", nullable = false)
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    var id: Int = 0,

    @Column(nullable = false, unique = true)
    val email: String = "",

    @Column(nullable = false)
    val name: String = "",

    @Column(nullable = false)
    val password: String = "",

    @Column(nullable = false)
    val username: String = ""
)