import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getPostById } from "../../modules/postManager";

export const PostDetail = () => {
  const [post, setPost] = useState({});
  const { postId } = useParams();

  useEffect(() => {
    getPostById(postId).then((p) => setPost(p));
  }, []);

  return (
    <>
      <div className="detail_Wrapper">
        <h3>{post.name}</h3>
      </div>
    </>
  );
};
