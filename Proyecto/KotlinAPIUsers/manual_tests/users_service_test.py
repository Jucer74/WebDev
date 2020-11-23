import json
import datetime
import http.client
from time import time

########################################################################################################################
##################################################### ENVIRONMENTS #####################################################
########################################################################################################################

# local
conn = http.client.HTTPConnection("localhost:8080")

# vagrant
# conn = http.client.HTTPConnection("192.168.56.119:8080")

# container
# conn = http.client.HTTPConnection("localhost:5000")

########################################################################################################################
######################################################## LOGIN #########################################################
########################################################################################################################

login_post = {
    'username': 'blue',
    'password': '123456'
}
json_data_post = json.dumps(login_post)
conn.request("POST", "/login", json_data_post, headers={'Content-type': 'application/json'})


########################################################################################################################
######################################################## USERS #########################################################
########################################################################################################################

#################################################
########## Encontrar un usuario por id ##########
#################################################

# headers = {
#     'Content-type': 'application/json',
#     'authorization': 'Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJibGFjayIsImlkZW50aXR5IjoiYmxhY2siLCJhdXRob3JpdGllcyI6WyJST0xFX1VTRVIiXSwiaWF0IjoxNjAyMDI0MzY2LCJleHAiOjE2MDIwMjQ5NjZ9.GhUpEW5xthqzcSIGVGUDjZA4UHhmDn5nlO6laM_d54BIkQhmL4qdM4cDLLLEQoXGG-G5AuvU5a4oEXiQOid0lg'
# }
# conn.request("GET", "/users/1", headers=headers)

############################################
########## Crear un nuevo usuario ##########
############################################
# headers = {
#     'Content-type': 'application/json',
#     'authorization': 'Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJibGFjayIsImlkZW50aXR5IjoiYmxhY2siLCJhdXRob3JpdGllcyI6WyJST0xFX1VTRVIiXSwiaWF0IjoxNjAyMDI0MzY2LCJleHAiOjE2MDIwMjQ5NjZ9.GhUpEW5xthqzcSIGVGUDjZA4UHhmDn5nlO6laM_d54BIkQhmL4qdM4cDLLLEQoXGG-G5AuvU5a4oEXiQOid0lg'
# }

# user_post = {
#     'email': 'mrwhite@gmail.com',
#     'username': 'white',
#     'password': 'qwerty',
#     'name': 'James White'
# }
# json_data_post = json.dumps(user_post)
# conn.request("POST", "/users", json_data_post, headers=headers)

############################################


start = datetime.datetime.now()
res = conn.getresponse()
end = datetime.datetime.now()

data = res.read()

elapsed = end - start

print(data.decode("utf-8"))
print("\"" + str(res.status) + "\"")
print("\"" + str(res.reason) + "\"")
print("\"elapsed seconds: " + str(elapsed) + "\"")

