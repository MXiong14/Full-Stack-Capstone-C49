import React, { useState, useEffect } from "react";
import { useParams, useHistory } from "react-router-dom";
import { getPostById, deletePost } from "../../modules/postManager";
import { Card, CardBody } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";

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
          <h2>Shoe Name: {post.name}</h2>
          <p className="post-size">Brand: {post.brand?.subBrand}</p>
          <p className="post-size">Username: {post.userProfile?.firstName}</p>
          <p className="post-size">Shoe Size: {post.size}</p>
          <p className="post-stylecode">Shoe Style Code: {post.styleCode}</p>
          <p className="post-quantity">Quantity: {post.quantity}</p>
          <p className="post-pp">Purchase Price: {post.purchasePrice}</p>
          <p className="post-sp">Sold Price: {post.soldPrice}</p>
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
        </CardBody>
      </Card>
    </>
  );
};
