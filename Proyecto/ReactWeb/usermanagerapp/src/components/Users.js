import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button, Container, Table } from 'react-bootstrap';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import 'jquery/dist/jquery.min.js';
import 'datatables.net-dt/js/dataTables.dataTables';
import 'datatables.net-dt/css/jquery.dataTables.min.css';
import $ from 'jquery'; 

const baseUrl = "https://localhost:5001/api";

export function List()
{

  const listUsersUrl = baseUrl + "/Users";
  const [ data, setData] = useState([]);

  const GetUsers = async() => {
    await axios.get(listUsersUrl)
    .then (response=>{
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }



  $(document).ready(function () {
    $('#UsersTable').DataTable();
  });

return (
  <Container className="text-center text-md-left">
    <h1>User List </h1>
    <p>
      <Button className="left" variant="success btn-sm"> <Fas icon={faPlus} /> New</Button>
    </p>  
    <Table id="UsersTable">
      <thead>
        <tr>
            <th>Id</th>
            <th>Email</th>
            <th>Name</th>
            <th>Username</th>
            <th>Password</th>
            <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {data.map(usr=>(
          <tr key={usr.id}>
            <td>{usr.id}</td>
            <td>{usr.email}</td>
            <td>{usr.name}</td>
            <td>{usr.username}</td>
            <td>{usr.password}</td>
            <td>
              <Button variant="outline-primary">Edit</Button>
              <Button variant="outline-warning">Edit</Button>
              <Button variant="outline-danger">Delete</Button>
            </td>
          </tr>
        ))}
    </tbody>
    </Table>
  </Container>  
);
}

export function CreateUser()
{

}