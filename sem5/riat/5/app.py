from flask import Flask, request, jsonify

app = Flask(__name__)

inventory = [
    {'element': "el"}
]


@app.route('/inventory')
def get_elements():
    return jsonify(inventory)


@app.route('/inventory/add', methods=['POST'])
def create_element():
    data = request.get_json()
    element = data.get('element')
    inventory_element = {'element': element}
    inventory.append(inventory_element)
    return jsonify({'message': 'Element created successfully'}), 201


@app.route('/inventory/<int:element_id>', methods=['GET'])
def get_element(element_id):
    if element_id >= len(inventory):
        return jsonify({'error': 'Element not found'}), 404
    return jsonify(inventory[element_id])


@app.route('/inventory/<int:element_id>', methods=['PUT'])
def update_element(element_id):
    if element_id >= len(inventory):
        return jsonify({'error': 'Element not found'}), 404
    data = request.get_json()
    inventory[element_id]['element'] = data.get('element')
    return jsonify({'message': 'Element updated successfully'})


@app.route('/inventory/<int:element_id>', methods=['DELETE'])
def delete_element(element_id):
    if element_id >= len(inventory):
        return jsonify({'error': 'Element not found'}), 404
    del inventory[element_id]
    return jsonify({'message': 'Element deleted successfully'})


@app.route('/inventory/len')
def inventory_len():
    return jsonify({'message': f'Inventory countains, {len(inventory)}, elements'})


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5001)