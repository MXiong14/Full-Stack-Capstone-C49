import React from "react";
import { useHistory } from "react-router-dom";
import { Card, CardBody } from "reactstrap";

export const Post = ({ post }) => {
  const history = useHistory();

  return (
    <>
      <Card>
        <p className="post-title">
          <h2
            onClick={() => {
              history.push(`/GetPostById/${post.id}`);
            }}
          >
            Name: {post.name}
          </h2>
        </p>
        <CardBody>
          <p className="post-size">Size: {post.size}</p>
        </CardBody>
      </Card>
    </>
  );
};
