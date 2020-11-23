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

def callback(ch, method, properties, body):
    print(" [x] Received %r" % body)

channel.basic_consume(queue='queue2',
                      on_message_callback=callback,
                      auto_ack=True)

print(' [*] Waiting for messages. To exit press CTRL+C')
channel.start_consuming()