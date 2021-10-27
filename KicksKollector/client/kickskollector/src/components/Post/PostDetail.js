import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getPostById } from "../../modules/postManager";
import { Card, CardBody } from "reactstrap";

export const PostDetail = ({}) => {
  const [post, setPost] = useState({});
  const [brand] = useState({});
  const { postId } = useParams();

  useEffect(() => {
    getPostById(postId).then((p) => setPost(p));
  }, []);

  return (
    <>
      <Card>
        <CardBody>
          <h2>{post.name}</h2>
          <p className="post-size">{post.size}</p>
          <p className="post-stylecode">{post.styleCode}</p>
          <p className="post-quantity">{post.quantity}</p>
          <p>{post.purchasePrice}</p>
          <p>{post.soldPrice}</p>
          <p>{brand.name}</p>
        </CardBody>
      </Card>
    </>
  );
};
