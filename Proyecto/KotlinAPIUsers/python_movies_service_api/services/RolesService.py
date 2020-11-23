from repositories.RolesRepository import RolesRepository

class RolesService(object):
    def __init__(self):
        self.roles_repository = RolesRepository()

    def add_rol(self, name):
        return self.roles_repository.add_rol(name)

    def get_all_roles(self, page, pagesize, name):
        return self.roles_repository.get_all_roles(page, pagesize, name)

    def get_rol_by_id(self, id):
        return self.roles_repository.get_rol_by_id(id)

    def update_rol(self, id, name):
        return self.roles_repository.update_rol(id, name)

    def delete_rol(self, id):
        return self.roles_repository.delete_rol(id)