from flask import Flask

app = Flask(__name__)

@app.route('/inventory')
def get_products():
    return 'List of inventory'

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5001)