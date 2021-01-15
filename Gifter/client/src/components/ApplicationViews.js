import React from "react";
import { Switch, Route } from "react-router-dom";
import PostList from "./PostList";
import PostForm from "./PostForm";
import PostDetails from "./PostDetails"
import Login from "./Login"
import Register from "./Login"


const ApplicationViews = () => {
    return (
        <Switch>
            <Route path="/login">
                <Login />
            </Route>

            <Route path="/register">
                <Register />
            </Route>

            <Route path="/" exact>
                <PostList />
            </Route>

            <Route path="/post/add">
                <PostForm />
            </Route>

            <Route path="/users/:id">
            </Route>

            <Route path="/post/:id"><PostDetails /></Route>
        </Switch>
    );
};

export default ApplicationViews;
