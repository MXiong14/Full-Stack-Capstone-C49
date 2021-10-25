import React, { useState, useEffect } from "react";
import { useParams, useHistory } from "react-router-dom";
import { getPostById, deletePost } from "../../modules/postManager";

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
        <h5>{post.brand?.name}</h5>
        <p>{post.userProfile?.displayName}</p>
        <p>{post.stylecode}</p>
        <p>{post.quantity}</p>
        <p>{post.purchaseprice}</p>
        <p>{post.soldprice}</p>
      </div>
    </>
  );
};
