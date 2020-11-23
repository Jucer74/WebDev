import pymysql
from db_config import mysql

class RolesRepository(object):
    def __init__(self):
        self.conn = mysql.connect()

    def add_rol(self, name):
        sql = "INSERT INTO roles(name) VALUES(%s)"
        data = (name,)
        cursor = self.conn.cursor()
        cursor.execute(sql, data)
        self.conn.commit()
        lastrowid = cursor.lastrowid
        cursor.close()
        return lastrowid

    def get_all_roles(self, page, pagesize, name):
        startat = page*pagesize
        cursor = self.conn.cursor(pymysql.cursors.DictCursor)
        if name:
            cursor.execute("SELECT id, name FROM roles WHERE name LIKE %s LIMIT %s, %s", (name,startat, pagesize))
        else:
            cursor.execute("SELECT id, name FROM roles LIMIT %s, %s", (startat, pagesize))

        rows = cursor.fetchall()
        cursor.close()
        return rows

    def get_rol_by_id(self, id):
        cursor = self.conn.cursor(pymysql.cursors.DictCursor)
        cursor.execute("SELECT id, name FROM roles WHERE id=%s", id)
        row = cursor.fetchone()
        cursor.close()
        return row

    def update_rol(self, id, name):
        sql = "UPDATE roles SET name=%s WHERE id=%s"
        data = (name, id,)
        cursor = self.conn.cursor()
        rows_affected = cursor.execute(sql, data)
        self.conn.commit()
        cursor.close()
        return rows_affected

    def delete_rol(self, id):
        cursor = self.conn.cursor()
        rows_affected = cursor.execute("DELETE FROM roles WHERE id=%s", (id,))
        self.conn.commit()
        cursor.close()
        return rows_affected