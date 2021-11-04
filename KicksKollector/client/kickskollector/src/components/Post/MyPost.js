import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { Post } from "./Post.js";
import { getByUser } from "../../modules/postManager.js";
import "bootstrap/dist/css/bootstrap.min.css";

export const MyPost = () => {
  const [posts, SetPosts] = useState([]);

  const getPost = () => {
    getByUser().then((posts) => SetPosts(posts));
  };

  useEffect(() => {
    getPost();
  }, []);

  return (
    <>
      <h1>My Inventory</h1>
      <Link to="/AddAShoe">
        <button>New Shoe</button>
      </Link>
      <section className="posts">
        {posts.map((post) => {
          return <Post post={post} id={post.id} />;
        })}
      </section>
    </>
  );
};
