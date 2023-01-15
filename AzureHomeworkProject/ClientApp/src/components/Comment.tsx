import React, {useState} from 'react'
import axios from 'axios';
import {useNavigate} from 'react-router-dom'

const Comment = () => {
  const [name, setName] = useState('');
  const [comment, setComment] = useState('')
  const navigate = useNavigate();

    const handleSubmit = (e) => {
      e.preventDefault();

      const payload = {name, comment}

      axios.post('/api/comments', payload).then(() => navigate('/'))
    }

  return (
    <div className="max-w-2xl mx-auto px-4 py-5 bg-white rounded-lg rounded-t-lg border border-gray-200 dark:bg-gray-800 dark:border-gray-700">
        <form method='post' onSubmit={handleSubmit}>
          <div className='py-2 px-4 mb-4'>
            <label>
              Name:
              <input 
                type="text"
                required value={name} 
                onChange={(e) => setName(e.target.value)}
                className='px-0 w-full rounded-sm text-sm text-gray-900 border-0 focus:ring-0 focus:outline-none dark:text-white dark:placeholder-gray-400 dark:bg-gray-800 h-10'
              />
            </label>
          </div>
          <div  className='py-2 px-4 mb-4'>
            <label>
              Write your comment:
              <textarea 
                className='p-2 w-full text-sm text-gray-900 border-0 focus:ring-0 focus:outline-none dark:text-white dark:placeholder-gray-400 dark:bg-gray-800' 
                name='comment' 
                placeholder='Writer your comment...' 
                required
                rows={10}
                cols={200}  
                value={comment} 
                onChange={(e) => setComment(e.target.value)} 
              />
            </label>
          </div>
          <button type='submit' className="mx-4 bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
            Post Comment
          </button>
        </form>
    </div>
  )
}

export default Comment