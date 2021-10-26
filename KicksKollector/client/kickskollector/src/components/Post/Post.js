import React from "react";
import { useHistory, Link } from "react-router-dom";
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
            {post.name}
          </h2>
        </p>
        <CardBody>
          <p className="post-size">{post.size}</p>
          <p className="post-stylecode">{post.styleCode}</p>
        </CardBody>
      </Card>
    </>
  );
};
