#!/usr/bin/env python
import pika

credentials = pika.PlainCredentials('admin', 'password')
connection = pika.BlockingConnection(pika.ConnectionParameters(
                                        '192.168.56.115', 
                                        5672, 
                                        '/', 
                                        credentials))
channel = connection.channel()

channel.queue_declare(queue='queue2')

channel.basic_publish(exchange='',
                      routing_key='queue2', #my_queue
                      body='Hello World!')
print(" [x] Sent 'Hello World!'")
connection.close()