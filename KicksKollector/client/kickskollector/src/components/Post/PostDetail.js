import React, { useState, useEffect } from "react";
import { useParams, useHistory } from "react-router-dom";
import { getPostById } from "../../modules/postManager";
import { Card, CardBody } from "reactstrap";

export const PostDetail = ({}) => {
  const [post, setPost] = useState({});
  const [brand] = useState({});
  const { postId } = useParams();
  const history = useHistory();

  const deletePost = (event) => {
    event.preventDefault();
    const confirmDelete = window.confirm(
      "Are you sure you want to delete this?",
    );
    if (confirmDelete) {
      deletePost(postId).then(() => {
        history.push("/MyInventory");
      });
    }
  };

  useEffect(() => {
    getPostById(postId).then((p) => setPost(p));
  }, []);

  if (!post) {
    return null;
  }

  return (
    <>
      <Card>
        <CardBody>
          <h2>Shoe name: {post.name}</h2>
          <p className="post-size">Shoe size: {post.size}</p>
          <p className="post-stylecode">Shoe style code: {post.styleCode}</p>
          <p className="post-quantity">Quantity: {post.quantity}</p>
          <p>Purchase price: {post.purchasePrice}</p>
          <p>Sold price: {post.soldPrice}</p>
          <button className="deleteButton" onClick={deletePost}>
            Delete Shoe
          </button>
          <button
            className="editButton"
            onClick={() => {
              history.push(`/EditAShoe/${post.id}`);
            }}
          >
            Edit Shoe
          </button>
        </CardBody>
      </Card>
    </>
  );
};
