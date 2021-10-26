import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import { Home } from "../Home";
import { MyPost } from "./Post/MyPost";
import { PostDetail } from "./Post/PostDetail";
import { PostList } from "./Post/PostList";

export default function ApplicationViews({ isLoggedIn }) {
  return (
    <main>
      <Switch>
        <Route exact path="/">
          <Home />
        </Route>

        <Route path="/AllPosts" exact>
          {isLoggedIn ? <PostList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/MyInventory" exact>
          {isLoggedIn ? <MyPost /> : <Redirect to="/login" />}
        </Route>

        <Route path="/GetPostById/:postId(\d+)" exact>
          {isLoggedIn ? <PostDetail /> : <Redirect to="/login" />}
        </Route>

        <Route path="/login">
          <Login />
        </Route>

        <Route path="/register">
          <Register />
        </Route>
      </Switch>
    </main>
  );
}
