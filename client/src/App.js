import React from 'react';
import { BrowserRouter as Router, Switch ,Route} from "react-router-dom";
import Home from "./Pages/Home";
import Machine from "./Pages/Machine";

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route
            exact
            path="/:id"
            component={Machine}
          />
          <Route
            path="/"
            component={Home}
          />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
