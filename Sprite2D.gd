extends Sprite2D

var speed = 400
var angular_speed = PI
var direction = 0
# Called when the node enters the scene tree for the first time.
func _ready():
	var timer = get_node("Timer")
	print(timer)
	timer.timeout.connect(_on_Timer_timeout)
	# timer.connect("timeout", self, "_on_Timer_timeout")


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if Input.is_action_pressed("ui_left"):
		direction = -1
	if Input.is_action_pressed("ui_right"):
		direction = 1
	rotation += angular_speed * direction * delta
	var velocity = Vector2.ZERO
	if Input.is_action_pressed("ui_up"):
		velocity = Vector2.UP.rotated(rotation) * speed
	if Input.is_action_pressed("ui_down"):
		velocity = Vector2.DOWN.rotated(rotation) * speed
	position += velocity * delta
	


func _on_button_pressed():
	set_process(not is_processing()) # Replace with function body.
	
func _on_Timer_timeout():
	visible = not visible
