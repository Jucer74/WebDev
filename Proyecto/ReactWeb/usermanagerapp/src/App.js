import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Layout } from './Layout';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { List } from './components/Users';
import { NoMatch } from './components/NoMatch';
import { NavigationBar } from './components/NavigationBar';
import { BrowserRouter as Router, Route, Switch  } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <React.Fragment>
        <NavigationBar/>
        <Layout>
          <Router>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/Home" component={Home} />
              <Route path="/Users" component={List} />
              <Route path="/Login" component={Login} />
              <Route component={NoMatch} />
            </Switch>
          </Router>
        </Layout>
      </React.Fragment>
    </div>
  );
}

export default App;
