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
          <p className="post-size">{post.size}</p>
          <p className="post-stylecode">{post.stylecode}</p>
        </CardBody>
      </Card>
    </>
  );
};
