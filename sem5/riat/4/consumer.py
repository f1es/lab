import pika
import sys


def callback(ch, method, properties, body):
    if body == b'right':
        print('Оборудование работает исправно')
        return
    if body == b'out_of_service':
        print('Оборудование не исправно')
        return
    if body == b'broken':
        print('Оборудование сломано и требует осблуживания')
        return
    print(f" [x] Recieved {body}")


connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
channel = connection.channel()
channel.basic_consume(queue=sys.argv[1], on_message_callback=callback, auto_ack=True)
print(' [*] Waiting for messanges. To exit, press Ctrl+C')
channel.start_consuming()