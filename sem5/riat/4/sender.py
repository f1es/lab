import random
import pika
import sys
import requests


def callback(ch, method, properties, body):
    print(f" [x] Recieved {body}")


def check_broker_availability():
    try:
        pika.BlockingConnection(pika.ConnectionParameters('localhost'))
        return True
    except:
        print('Брокер сообщений недоступен')
        return False


def send_message_to_broker(message, routing_key):
    if message == '':
        print('Сообщение пустое')
        return

    connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    channel = connection.channel()
    channel.basic_publish(exchange='', routing_key=routing_key, body=message)
    print(f'Сообщение {message} успешно отправлено')


def create_broker_queue(queue_name):
    connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    channel = connection.channel()
    channel.queue_declare(queue=queue_name)


def get_crypto_data():
    api_key = "CG-Z7qPwTTjshcC2vZ4rnpRm1qM"
    response = requests.get(f'https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&x_cg_api_key={api_key}')
    data = response.json()
    str = ""

    for coin in data:
        print(f"{coin['name']} ({coin['symbol']})")
        print(f"\tprice: {coin['current_price']}")
        str += f"{coin['name']} ({coin['symbol']})"
        str += f"\tprice: {coin['current_price']}"
        str += "\n"
    return str

def generate_event():
    events = {1 : 'right', 2 : 'out_of_service', 3 : 'broken'}
    return events[random.randint(1, 3)]

####################################################

if len(sys.argv) == 1:
    exit()

if sys.argv[1] == 'send_messange':          #send messange
    if len(sys.argv) == 2:
        print('Отсутствует сообщение')
        exit()
    if len(sys.argv) == 3:
        print('Отсутствует ключ')
        exit()

    messange = sys.argv[2]
    key = sys.argv[3]
    if check_broker_availability() == False:
        exit()
    send_message_to_broker(sys.argv[2], sys.argv[3])

if sys.argv[1] == 'create_queue':           #create queue
    if len(sys.argv) == 2:
        print('Отсутствует имя очереди')
        exit()

    if check_broker_availability() == False:
        exit()

    broker_name = sys.argv[2]
    create_broker_queue(broker_name)
    print(f'очередь {broker_name} успешно создана')


if sys.argv[1] == 'send_crypto_data':       #send crypto data
    if len(sys.argv) == 2:
        print('Отсутствует ключ')
        exit()

    if check_broker_availability() == False:
        exit()

    key = sys.argv[2]
    send_message_to_broker(get_crypto_data(), key)
    print(f'Данные о цене успешно криптовалют отправлены')


if sys.argv[1] == 'generate_event':       #generate event
    if len(sys.argv) == 2:
        print('Отсутствует ключ')
        exit()

    if check_broker_availability() == False:
        exit()

    key = sys.argv[2]
    send_message_to_broker(generate_event(), key)
    print(f'Событие создано')


if sys.argv[1] == 'help':                 #help
    print(' send_messange \t\t(messange) (routing key)')
    print(' create_queue \t\t(queue name)')
    print(' send_crypto_data\t(routing key)')
    print(' generate_event \t(key)')


#if check_broker_availability():
    #connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
    #channel = connection.channel()
    #create_broker_queue('hello')
    #send_message_to_broker('asdsg', 'hello')
#else:
#    print('Брокер сообщений недоступен')

#connection.close()

