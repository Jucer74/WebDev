from flask import Blueprint
from app import app
from services.RolesService import RolesService
from flask import jsonify
from flask import flash, request
from flask_jwt_extended import (
    jwt_required, fresh_jwt_required, JWTManager, jwt_refresh_token_required,
    jwt_optional, create_access_token, create_refresh_token, get_jwt_identity,
    decode_token
)

roles_api = Blueprint('roles_api', __name__)

roles_service = RolesService()

@roles_api.route('/rol',
                 methods=['POST'])
@jwt_required
def add_rol():
    try:
        _json = request.json
        _name = _json['name']
        # validate the received values
        if _name and request.method == 'POST':
            lastrowid = roles_service.add_rol(_name)
            resp = jsonify({'id': lastrowid})
            resp.status_code = 201
            return resp
        else:
            return not_found()
    except Exception as e:
        print(e)

@roles_api.route('/rol',
                 methods=['GET'])
@jwt_required
def get_all_roles():
    try:
        page = request.args.get('page', default = 0, type = int)
        name = request.args.get('name', default = None, type = str)
        app.logger.info("page: " + str(page))
        
        pagesize = 2
        rows = roles_service.get_all_roles(page, pagesize, name)
        resp = jsonify(rows)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@roles_api.route('/rol/<int:id>',
                 methods=['GET'])
@jwt_required
def get_rol_by_id(id):
    try:
        row = roles_service.get_rol_by_id(id)
        resp = jsonify(row)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@roles_api.route('/rol/<int:id>',
                 methods=['PUT'])
@jwt_required
def update_rol(id):
    try:
        _json = request.json
        _name = _json['name']
        # validate the received values
        if _name and id and request.method == 'PUT':
            rows_affected = roles_service.update_rol(id, _name)
            app.logger.info("PUT update_rol, rows_affected: " + str(rows_affected))
            if rows_affected == 0:
                resp = jsonify({'message': 'Rol was not updated!'})
                resp.status_code = 200
            else:
                resp = jsonify({'message': 'Rol updated successfully!'})
                resp.status_code = 200
            return resp
        else:
            return not_found()
    except Exception as e:
        print(e)

@roles_api.route('/rol/<int:id>',
                 methods=['DELETE'])
@jwt_required
def delete_rol(id):
    try:
        rows_affected = roles_service.delete_rol(id)
        if rows_affected == 0:
            resp = jsonify({'message': 'Rol was not deleted!'})
            resp.status_code = 200
        else:
            resp = jsonify({'message': 'Rol deleted successfully!'})
            resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@roles_api.errorhandler(404)
def not_found(error=None):
    message = {
        'status': 404,
        'message': 'Not Found: ' + request.url,
    }
    resp = jsonify(message)
    resp.status_code = 404

    return resp