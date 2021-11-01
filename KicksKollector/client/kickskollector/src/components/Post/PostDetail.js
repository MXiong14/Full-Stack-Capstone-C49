import React, { useState, useEffect } from "react";
import { useParams, useHistory } from "react-router-dom";
import { getPostById, deletePost } from "../../modules/postManager";
import { Card, CardBody } from "reactstrap";

export const PostDetail = () => {
  const [post, setPost] = useState({});
  const [brand, setBrand] = useState({});
  const { postId } = useParams();
  const history = useHistory();

  const deleteThePost = (event) => {
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
          <button className="deleteButton" onClick={deleteThePost}>
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
          <h2>Shoe name: {post.name}</h2>
          <p className="brand-name">Brand name: {brand.name}</p>
          <p className="post-size">Shoe size: {post.size}</p>
          <p className="post-stylecode">Shoe style code: {post.styleCode}</p>
          <p className="post-quantity">Quantity: {post.quantity}</p>
          <p className="post-pp">Purchase price: {post.purchasePrice}</p>
          <p className="post-sp">Sold price: {post.soldPrice}</p>
        </CardBody>
      </Card>
    </>
  );
};
