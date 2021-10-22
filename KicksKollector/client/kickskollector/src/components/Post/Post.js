import React from "react";
import { useHistory, Link } from "react-router-dom";
import { Card, CardBody } from "reactstrap";

export const Post = ({ post }) => {
  const history = useHistory();

  return (
    <>
      <Card>
        <Link to={`/GetPostById/edit/${post.id}`}>
          <button>Edit Post</button>
        </Link>
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
          <p className="post-content">{post.size}</p>
          <p className="post-content">{post.stylecode}</p>
        </CardBody>
      </Card>
    </>
  );
};
